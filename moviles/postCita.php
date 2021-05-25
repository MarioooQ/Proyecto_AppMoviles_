
<?php
include "config.php";
include "utils.php";

$dbConn =  connect($dbs);

if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
  if (isset($_GET['PK_PACIENTE']))
  {
    //Mostrar un post
    $sql = $dbConn->prepare("SELECT * FROM t_cita where PK_PACIENTE=:PK_PACIENTE");
    $sql->bindValue(':PK_PACIENTE', $_GET['PK_PACIENTE']);
    $sql->execute();
    header("HTTP/1.1 200 OK");
    echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
    exit();
  }
  else 
  {
    //Mostrar lista de post
    $sql = $dbConn->prepare("SELECT * FROM t_cita");
    $sql->execute();
    $sql->setFetchMode(PDO::FETCH_ASSOC);
    header("HTTP/1.1 200 OK");
    echo json_encode( $sql->fetchAll()  );
    exit();
  }
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
  $input = $_POST;
  $sql = "INSERT INTO t_cita
        (PK_PACIENTE, FECHACITA, RAZON)
        VALUES
        (:PK_PACIENTE, :FECHACITA, :RAZON)";
  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);
  $statement->execute();

  $postPK_PACIENTE = $dbConn->lastInsertId();
  if($postPK_PACIENTE)
  {
    $input['PK_PACIENTE'] = $postPK_PACIENTE;
    header("HTTP/1.1 200 OK");
    echo json_encode($input);
    exit();
  }
}

if ($_SERVER['REQUEST_METHOD'] == 'DELETE')
{
  $PK_CITA = $_GET['PK_CITA'];
  $statement = $dbConn->prepare("DELETE FROM  t_cita where PK_CITA=:PK_CITA");
  $statement->bindValue(':PK_CITA', $PK_CITA);
  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
  $input = $_GET;
  $postPK_CITA = $input['PK_CITA'];
  $fields = getParams($input);

  $sql = "
        UPDATE t_cita
        SET $fields
        WHERE PK_CITA='$postPK_CITA'
          ";

  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);

  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}
?>
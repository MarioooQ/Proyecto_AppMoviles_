
<?php
include "config.php";
include "utils.php";

$dbConn =  connect($dbs);

if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
  if (isset($_GET['PK_USUARIO']))
  {
    //Mostrar un post
    $sql = $dbConn->prepare("SELECT * FROM t_paciente where PK_USUARIO=:PK_USUARIO");
    $sql->bindValue(':PK_USUARIO', $_GET['PK_USUARIO']);
    $sql->execute();
    header("HTTP/1.1 200 OK");
    echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
    exit();
  }
  else 
  {
    if(isset($_GET['PK_PACIENTE']))
    {
      $sql = $dbConn->prepare("SELECT * FROM t_paciente where PK_PACIENTE=:PK_PACIENTE");
      $sql->bindValue(':PK_PACIENTE', $_GET['PK_PACIENTE']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
    }
    else
    {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT * FROM t_paciente");
      $sql->execute();
      $sql->setFetchMode(PDO::FETCH_ASSOC);
      header("HTTP/1.1 200 OK");
      echo json_encode( $sql->fetchAll()  );
      exit();
    }

  }
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
  $input = $_POST;
  $sql = "INSERT INTO t_paciente
        (PK_USUARIO, NOMBRE, APELLIDO, IDENTIFICACION, FECHANACIMIENTO, DIRECCION, GENERO, TELEFONO, ALERGIAS, EC_S)
        VALUES
        (:PK_USUARIO, :NOMBRE, :APELLIDO, :IDENTIFICACION, :FECHANACIMIENTO, :DIRECCION, :GENERO, :TELEFONO, :ALERGIAS, :EC_S)";
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
  $PK_PACIENTE = $_GET['PK_PACIENTE'];
  $statement = $dbConn->prepare("DELETE FROM  t_paciente where PK_PACIENTE=:PK_PACIENTE");
  $statement->bindValue(':PK_PACIENTE', $PK_PACIENTE);
  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
  $input = $_GET;
  $postPK_USUARIO = $input['PK_USUARIO'];
  $fields = getParams($input);

  $sql = "
        UPDATE t_paciente
        SET $fields
        WHERE PK_USUARIO='$postPK_USUARIO'
          ";

  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);

  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}
?>
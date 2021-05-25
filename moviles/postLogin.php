
<?php
include "config.php";
include "utils.php";

$dbConn =  connect($dbs);

if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
  if (isset($_GET['PK_USUARIO']))
  {
    //Mostrar un post
    $sql = $dbConn->prepare("SELECT * FROM t_login where PK_USUARIO=:PK_USUARIO");
    $sql->bindValue(':PK_USUARIO', $_GET['PK_USUARIO']);
    $sql->execute();
    header("HTTP/1.1 200 OK");
    echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
    exit();
  }
  else 
  {
    //Mostrar lista de post
    $sql = $dbConn->prepare("SELECT * FROM t_login");
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
  $sql = "INSERT INTO t_login
        (USUARIO, CONTRASENA)
        VALUES
        (:USUARIO, :CONTRASENA)";
  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);
  $statement->execute();

  $postPK_LOGIN = $dbConn->lastInsertId();
  if($postPK_LOGIN)
  {
    $input['PK_LOGIN'] = $postPK_LOGIN;
    header("HTTP/1.1 200 OK");
    echo json_encode($input);
    exit();
  }
}
/*
if ($_SERVER['REQUEST_METHOD'] == 'DELETE')
{
  $PK_USUARIO = $_GET['PK_USUARIO'];
  $statement = $dbConn->prepare("DELETE FROM  t_login where PK_LOGIN=:PK_LOGIN");
  $statement->bindValue(':PK_USUARIO', $PK_USUARIO);
  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}*/

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
  $input = $_GET;
  $postPK_LOGIN = $input['PK_LOGIN'];
  $fields = getParams($input);

  $sql = "
        UPDATE t_login
        SET $fields
        WHERE PK_USUARIO='$postPK_LOGIN'
          ";

  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);

  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}
?>
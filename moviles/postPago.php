<?php
include "config.php";
include "utils.php";


if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
  $input = $_POST;
  $postPK_CITA = $input['PK_CITA'];

  $postPago = $input['PAGO'];
  
  $sql = "
        UPDATE t_cita
        SET PAGO=:PAGO
        WHERE PK_CITA=:PK_CITA
          ";

  $statement = $dbConn->prepare($sql);

  bindValue(':PK_CITA', $postPK_CITA);
  bindValue(':RAZON', $postPago)

  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}


?>
<?php
if (isset($_POST['submit'])) {
    $name = $_POST['name'];
    $email = $_POST['email'];
    $phone = $_POST['phone'];
    $comments = $_POST['comments'];
    $to = 'atahjid@gmail.com';
    $subject= 'Mail From Portfolio Site';
    $message = "
    <html>
    <body>
        <div style='padding:10px;background:#fff;'>
            <p>
                Name : $name,
                Email Address : $email,
                <br>
                Phone : $phone,
            </p>
            <p>
                $comments.
            </p>
        </div>
    </body>
</html>";
$headers  = 'MIME-Version: 1.0' . "\r\n";
$headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";
$headers .= 'From: '.$name.' <'.$email.'>'."\r\n";
$alert = (mail($to, $subject, $message, $headers));
}
?>
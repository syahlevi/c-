function cekusername()
{
    var username = document.getElementById('txtusername').value;
    if(username=="")
    {
        
        alert("Username Anda Adalah : Kosong");
    }
    else
    {
        alert("Username Anda Adalah :" +username);
    }
}

function cekusernamelength()
{
    var username = document.getElementById('txtusername').value;
    var s = username.length;
    if (username == "") {
        username = "null";
        alert("Username Anda Adalah : "+username+" \nPanjang Username Anda Adalah :"+s);

    }
    else {
        alert("Username Anda Adalah : " + username + " dan Panjang Username Anda Adalah :" + s);

    }
}

function perulangan()
{
    var username = document.getElementById('txtusername').value;
    var s = username.length;
    var temp = 'angka';
    var angka = 0;
    var count = temp.length;
    var s = 0;
    while (angka <count)
    {
        alert(temp[angka]);
        angka++;
    }
}




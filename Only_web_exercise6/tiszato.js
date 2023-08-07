function turizmus(melyik){
    document.getElementById('turizmusszovegkeret').style.display='none';
    document.getElementById('turizmuskep').src=melyik+'C:\Gere Csaba\Programozás\20220302\Tisza_középágazatis\web-erettsegi-2020oktober\kepek';
    document.getElementById('turizmuskepkeret').style.display='block';   
}

function keprejt(){
  document.getElementById('turizmuskepkeret').style.display='none';
  document.getElementById('turizmusszovegkeret').style.display='block';    
}


function voltarPagina(botao) {
    document.getElementById(botao).addEventListener('click', function (event) {
        event.preventDefault(); 
        history.back(); 
    });


}



    

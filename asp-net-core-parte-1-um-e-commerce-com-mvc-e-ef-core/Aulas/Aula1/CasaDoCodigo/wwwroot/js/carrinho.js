
class Carrinho {

    clickIncremento(btn) {

        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuatidade(data);
    }

    clickDecremento(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuatidade(data);
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQtde = $(linhaDoItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuatidade(data);
    }

    postQuatidade(data) {
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            
        });
    }
}

var carrinho = new Carrinho();
"use strict";
(function () {
	var container,
		model = new BoardModel(),
		cellsCollection = new CellsCollection(),
		board;
	
	model.set('aliveCells',  cellsCollection)
	board = new BoardWidget({ model: model });
	
	$(function () {
		
		container = $('#testBoard');
		
		cellsCollection.on('reset', function () {
			container.append(board.render().$el);
		});
		
		$('button').click(newGame);
	});
	
	function newGame() {
		var rows = $('input[name=rows]').val(),
		columns= $('input[name=columns]').val();
		
		model.set('rows', rows);
		model.set('columns', columns);
		
		cellsCollection.fetch();
	}

})()
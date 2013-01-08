//"use strict";
(function () {
	var container,
		model = new BoardModel(),
		cellsCollection = new CellsCollection(),
		board;
	
	model.set('aliveCells',  cellsCollection)
	board = new BoardWidget({ model: model });
	
	$(function () {
		
		container = $('#testBoard');
		
		model.on('reset', function () {
			container.append(board.render().$el);
		});
		
		$('button').click(newGame);
	});
	
	function newGameSuccess(data) {
		cellsCollection.reset(data);
		container.append(board.render().$el);
		setTimeout(updateToNextGeneration, 1000)
	}
	
	function newGame() {
		var rows = $('input[name=rows]').val(),
		columns= $('input[name=columns]').val();
		
		model.set('rows', rows);
		model.set('columns', columns);
		
		var data = model.toJSON();
		
		$.ajax({
			  type: 'POST',
			  url: model.url,
			  data: JSON.stringify({ "rows": rows, "columns": columns }),
			  success: newGameSuccess,
			  dataType: "json",
			  contentType: 'application/json'
			});
	}
	
	function updateToNextGeneration() {
		var data = cellsCollection.toJSON();
		$.ajax({
			  type: 'POST',
			  url: cellsCollection.url,
			  data: JSON.stringify(data),
			  success: updateToNextGenerationSuccess,
			  dataType: "json",
			  contentType: 'application/json'
			});
	}
	
	function updateToNextGenerationSuccess(data) {
		cellsCollection.reset(data);
		setTimeout(updateToNextGeneration, 1000)
		container.append(board.render().$el);
	}
	
})()
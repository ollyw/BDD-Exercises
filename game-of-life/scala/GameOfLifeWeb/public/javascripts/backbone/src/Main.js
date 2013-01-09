//"use strict";
(function () {
	var container,
		model = new BoardModel(),
		board;
	
	board = new BoardWidget({ model: model });
	
	$(function () {
		
		container = $('#testBoard');
		
		model.on('reset', function () {
			container.append(board.render().$el);
		});
		
		$('#newGame').click(newGame);
		$('#replayGame').click(replayGame);
		$('#exampleGame').click(exampleGame);
	});
	
	function newGameSuccess(data) {
		model.start(data);
		container.append(board.render().$el);
		setTimeout(updateToNextGeneration, 1500)
	}
	
	function replayGame() {
		model.replay();
		container.append(board.render().$el);
		setTimeout(updateToNextGeneration, 1500);
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
	
	function exampleGame() {
		var sample = [{"row":4,"column":14},{"row":10,"column":17},{"row":14,"column":1},{"row":5,"column":10},{"row":12,"column":1},{"row":13,"column":17},{"row":2,"column":17},{"row":4,"column":15},{"row":12,"column":11},{"row":8,"column":16},{"row":8,"column":15},{"row":2,"column":7},{"row":7,"column":15},{"row":8,"column":14},{"row":3,"column":8},{"row":9,"column":19},{"row":5,"column":3},{"row":10,"column":15},{"row":9,"column":14},{"row":10,"column":18}]
		model.set('rows', 20);
		model.set('columns', 40);
		model.get('seedCells').reset(sample);
		model.replay();
	}
	
	function updateToNextGeneration() {
		var data = model.get('aliveCells').toJSON();
		$.ajax({
			  type: 'POST',
			  url: model.get('aliveCells').url,
			  data: JSON.stringify(data),
			  success: updateToNextGenerationSuccess,
			  dataType: "json",
			  contentType: 'application/json'
			});
	}
	
	function updateToNextGenerationSuccess(data) {
		model.update(data);
		container.append(board.render().$el);
		setTimeout(updateToNextGeneration, 1500)
	}
	
})()
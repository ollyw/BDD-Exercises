//"use strict";
(function () {
	var container,
		model = new BoardModel(),
		board,
		timer,
		interval = 750;
	
	board = new BoardWidget({ model: model });
	
	$(function () {
		
		container = $('#testBoard');
		
		$('#newGame').click(newGame);
		$('#replayGame').click(replayGame);
		$('#exampleGame').click(exampleGame);
	});
	
	function newGameSuccess(data) {
		model.start(data);
		container.append(board.render().$el);
		timer = setTimeout(updateToNextGeneration, interval)
	}
	
	function replayGame() {
		clearInterval(timer);
		updateBoardDimensions();
		
		model.replay();
		container.append(board.render().$el);
		timer = setTimeout(updateToNextGeneration, interval);
	}
	
	function updateBoardDimensions() {
		var rows = $('input[name=rows]').val(),
		columns= $('input[name=columns]').val();
		
		model.set('rows', rows);
		model.set('columns', columns);
	}
	
	function newGame() {
		clearInterval(timer);
		
		updateBoardDimensions();
		var data = model.toJSON();
		
		$.ajax({
			  type: 'POST',
			  url: model.url,
			  data: JSON.stringify({ "rows": model.get('rows'), "columns": model.get('columns') }),
			  success: newGameSuccess,
			  dataType: "json",
			  contentType: 'application/json'
			});
	}
	
	function exampleGame() {
		clearInterval(timer);
		
		var sample = [{"row":4,"column":14},{"row":10,"column":17},{"row":14,"column":1},{"row":5,"column":10},{"row":12,"column":1},{"row":13,"column":17},{"row":2,"column":17},{"row":4,"column":15},{"row":12,"column":11},{"row":8,"column":16},{"row":8,"column":15},{"row":2,"column":7},{"row":7,"column":15},{"row":8,"column":14},{"row":3,"column":8},{"row":9,"column":19},{"row":5,"column":3},{"row":10,"column":15},{"row":9,"column":14},{"row":10,"column":18}]
		model.set('rows', 20);
		model.set('columns', 40);
		model.get('seedCells').reset(sample);
		model.replay();
		
		timer = setTimeout(updateToNextGeneration, interval)
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
		updateBoardDimensions();
		container.append(board.render().$el);
		timer = setTimeout(updateToNextGeneration, interval)
	}
	
})()
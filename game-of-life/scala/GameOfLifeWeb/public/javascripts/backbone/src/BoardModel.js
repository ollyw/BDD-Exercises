var BoardModel = Backbone.Model.extend({
	url: 'http://localhost:9000/gameoflife/newgame',
	defaults: { rows: null, columns: null, aliveCells: new CellsCollection() }
});

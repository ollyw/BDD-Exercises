var BoardModel = Backbone.Model.extend({
	
	url: 'http://localhost:9000/gameoflife/newgame',
	
	defaults: { rows: null, columns: null, aliveCells: new CellsCollection(), seedCells: new CellsCollection() },
	
	start: function (seedCells) {
		this.get('seedCells').reset(seedCells);
		this.get('aliveCells').reset(seedCells);
	},
	
	update: function (newCells) {
		this.get('aliveCells').reset(newCells);
	},
	
	replay: function () {
		this.get('aliveCells').reset(this.get('seedCells').toJSON())
	}
});

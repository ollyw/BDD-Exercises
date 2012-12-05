var BoardModel = Backbone.Model.extend({
	defaults: { rows: null, columns: null, aliveCells: new CellsCollection() }
});

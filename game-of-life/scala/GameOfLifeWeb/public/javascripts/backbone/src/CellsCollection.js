var CellsCollection = Backbone.Collection.extend({
	model: CellModel,
	url: 'http://localhost:9000/gameoflife/nextgeneration'
});

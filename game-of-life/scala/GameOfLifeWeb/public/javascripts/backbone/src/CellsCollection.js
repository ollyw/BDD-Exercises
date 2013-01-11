var CellsCollection = Backbone.Collection.extend({
	model: CellModel,
	url: '/gameoflife/nextgeneration'
});

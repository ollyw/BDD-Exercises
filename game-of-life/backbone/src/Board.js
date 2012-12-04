var Board = Backbone.Model.extend({});

var BoardWidget = Backbone.View.extend({
	
	tagName: 'table',

	className: 'boardview',

	render : function () {
		var board = [this.model.rows][this.model.columns],
			row,
			column,
			html = '';

		html += '<tbody>';
		for (row = 0; row < this.model.rows; row++) {
			html += '<tr>';
			for (column = 0; column < this.model.columns; column++) {
				html += '<td></td>';
			}
			html += '</tr>';
		}
		html += '</tbody>';

		this.$el.append(html);

		return this;
	}
});
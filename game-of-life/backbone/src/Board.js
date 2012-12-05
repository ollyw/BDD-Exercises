var Board = Backbone.Model.extend({});

var BoardWidget = Backbone.View.extend({
	
	tagName: 'table',

	className: 'boardview',

	render : function () {
		var board = [this.model.rows][this.model.columns],
			row,
			column,
			html = '',
			alive;

		html += '<tbody>';
		for (row = 0; row < this.model.rows; row++) {
			html += '<tr>';
			for (column = 0; column < this.model.columns; column++) {
				alive = _.some(this.model.aliveCells, function (item) {
					return (item.row === (row + 1) && item.column === (column + 1));
				});
				if (alive) {
					html += '<td class="alive">1</td>';
				} else {
					html += '<td class="dead">0</td>';
				}
			}
			html += '</tr>';
		}
		html += '</tbody>';

		this.$el.append(html);

		return this;
	}
});
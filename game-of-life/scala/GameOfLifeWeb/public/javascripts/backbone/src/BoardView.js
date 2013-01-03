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
		for (rowIndex = 0; rowIndex < this.model.get('rows'); rowIndex ++) {
			html += '<tr>';
			for (columnIndex = 0; columnIndex < this.model.get('columns'); columnIndex ++) {
				alive = this.model.get('aliveCells').some(function (item) {
					return (item.get('row') === (rowIndex) && item.get('column') === (columnIndex));
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

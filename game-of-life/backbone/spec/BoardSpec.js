describe("Board Widget", function() {
	describe("render", function () {
		var container = $('<div id="testBoard" style="top: 100px; left: 100px; position:absolute;"></div>');

		beforeEach(function() {
			$('body').append(container);
		});

		afterEach(function() {
			//container.empty();
		});

    		it("should layout a table with the correct dimensions", function() {
			var model = new Board(),
				board;

			model.rows = 10;
			model.columns = 10;
			board = new BoardWidget({ model: model });

			container.append(board.render().$el);

			expect(board.$el.find('tr').length).toBe(10);
			expect(board.$el.find('td').length).toBe(100);
		});
	});
});
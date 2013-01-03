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
			var model = new BoardModel(),
				board;

			model.set('rows', 10);
			model.set('columns', 10);
			board = new BoardWidget({ model: model });

			container.append(board.render().$el);

			expect(board.$el.find('tr').length).toBe(10);
			expect(board.$el.find('td').length).toBe(100);
		});

		it('should display the life state of cells correctly', function () {
			var model = new BoardModel(),
				board;
			
			model.set('rows', 2);
			model.set('columns', 3);
			model.set('aliveCells',  new CellsCollection( [ { row: 1, column: 2 },
							     { row: 2, column: 3 } ]))

			board = new BoardWidget({ model: model });

			container.append(board.render().$el);

			expect(board.$el.find('tr:nth-child(1) td:nth-child(1).dead').length).toBe(1);
			expect(board.$el.find('tr:nth-child(1) td:nth-child(2).alive').length).toBe(1);
			expect(board.$el.find('tr:nth-child(1) td:nth-child(3).dead').length).toBe(1);
			expect(board.$el.find('tr:nth-child(2) td:nth-child(1).dead').length).toBe(1);
			expect(board.$el.find('tr:nth-child(2) td:nth-child(2).dead').length).toBe(1);
			expect(board.$el.find('tr:nth-child(2) td:nth-child(3).alive').length).toBe(1);
		});
	});
});

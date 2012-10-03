describe("Round", function() {
 describe("Ranking winners", function() {
  it("should place stone above scissors", function() {
    var round = new Round();
    round.registerChoice(1, "stone");
    round.registerChoice(2, "scissors");
    expect(round.getRanking()).toEqual([[1],[2]]);
  });
  it("should place scissors above paper", function() {
    var round = new Round();
    round.registerChoice(1, "scissors");
    round.registerChoice(2, "paper");
    expect(round.getRanking()).toEqual([[1], [2]]);
  });
  it("should place paper above stone", function() {
    var round = new Round();
    round.registerChoice(1, "paper");
    round.registerChoice(2, "stone");
    expect(round.getRanking()).toEqual([[1], [2]]);
  });
  it("should draw when selections are the same", function() {
    var round = new Round();
    round.registerChoice(1, "paper");
    round.registerChoice(2, "paper");
    expect(round.getRanking()).toEqual([[1, 2]]);
  });
 });
});
describe("Round", function() {
 describe("Selecting a winner", function() {
  it("should choose stone above scissors", function() {
    var round = new Round();
    round.registerChoice(1, "stone");
    round.registerChoice(2, "scissors");
    expect(round.selectWinner()).toEqual(1);
  });
  it("should choose scissors above paper", function() {
    var round = new Round();
    round.registerChoice(1, "scissors");
    round.registerChoice(2, "paper");
    expect(round.selectWinner()).toEqual(1);
  });
  it("should choose paper above stone", function() {
    var round = new Round();
    round.registerChoice(1, "paper");
    round.registerChoice(2, "stone");
    expect(round.selectWinner()).toEqual(1);
  });
 });
});
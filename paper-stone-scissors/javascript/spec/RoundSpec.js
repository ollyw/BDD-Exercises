describe("Round", function() {  
  it("should choose scissors as the winner above stone", function() {
    var round = new Round();
    round.registerChoice(1, "scissors");
    round.registerChoice(2, "stone");
    expect(round.selectWinner()).toEqual(1);
  });
});
describe("FirstToGame", function() {  
  it("should finish when one player scores the winning score", function() {
    var gameOverCallback = jasmine.createSpy();
    
    var game = new FirstToGame({
        winningScore: 3,
        numberOfPlayers: 2,
        gameOverCallback: gameOverCallback
    });
    
    game.registerWinForPlayer(1);
    expect(gameOverCallback).not.toHaveBeenCalled();
    
    game.registerWinForPlayer(1);
    expect(gameOverCallback).not.toHaveBeenCalled();
    
    game.registerWinForPlayer(2);
    expect(gameOverCallback).not.toHaveBeenCalled();
    
    game.registerWinForPlayer(1);
    expect(gameOverCallback).toHaveBeenCalled();
  });
});
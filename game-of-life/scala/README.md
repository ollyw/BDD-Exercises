#Scala Game Of Life

**N.B. This is a work in progress**

This folder contains an Implementation of the Game of Life, that was used to advance my knowledge in Scala. 

The high level view of the project is:
- An implementation of the Game Of Life business logic, developed with BDD using ScalaTest.
- A web site which acts as a json service for the game of life, developed using the Play Framework
- A backbone.js implementation of the client (the backbone implementation is not the focus of this project, and requires a clean up)

More information on this project can be found in this online presentation:
http://prezi.com/dws1sbd-mg-n/learning-scala/

To get started:
- Ensure you have Java 1.6 SDK
- Install SBT (on a Mac, using Homebrew is easiest)
- Download and unzip the Play framework into this folder in your working directory. I used Play 2.0.4.
- Change to GameOfLife folder and run sbt publish-local. A jar should be compiled and put into the local IVY repository
- Change to GameOfLifeWeb folder and run ../play.2.0.4/play run
- Navigate to localhost:9000 and the game of life should appear.

Please do get in touch if you have any issues/trouble, as 'it works for me'TM and I haven't tested it on another machine yet

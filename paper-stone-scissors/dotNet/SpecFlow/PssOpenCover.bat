cd C:\Users\valtechuk\Documents\olly-docs\Agile QA\Exercises\PaperStoneScissors\PaperStoneScissorsTest2\PaperStoneScissors.Test\bin\Debug

opencover.console "-target:c:\Program Files\Gallio\bin\Gallio.Echo.exe" -log:All "-targetargs:PaperStoneScissors.Test.dll" -output:opencover.coverage.txt -register -filter:+[Paper*]* -showunvisited


REM partcover --target "c:\Program Files\Gallio\bin\Gallio.Echo.exe" --target-args "PaperStoneScissors.Test.dll" --output partcover.coverage.txt
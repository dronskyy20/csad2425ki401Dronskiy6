void setup() {
  Serial.begin(9600); 
}

void loop() {
  if (Serial.available()) {  
    String clientMove = Serial.readStringUntil('\n');  
    String serverMove = getRandomMove();  

    Serial.println("Client move: " + clientMove);  
    Serial.println("Server move: " + serverMove);  

    String result = determineWinner(clientMove, serverMove);  
    Serial.println(result);  
  }
}

String getRandomMove() {
  int randomNumber = random(0, 3);  
  if (randomNumber == 0) return "Rock";      
  else if (randomNumber == 1) return "Paper"; 
  else return "Scissors";                      
}


String determineWinner(String clientMove, String serverMove) {
  if (clientMove == serverMove) return "Draw"; 
  if ((clientMove == "Rock" && serverMove == "Scissors") ||
      (clientMove == "Paper" && serverMove == "Rock") ||
      (clientMove == "Scissors" && serverMove == "Paper")) {
    return "Client wins!";
  } else {
    return "Server wins!";
  }
}

void setup() {
  Serial.begin(9600); 
  delay(1000);
  Serial.println("Hello Server!"); 
}

void loop() {
  if (Serial.available()) {
    String response = Serial.readStringUntil('\n'); 
    Serial.println("Received from server: " + response);
    delay(1000); 
  }
}


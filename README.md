# gpsModuleVakasi
https://docs.arduino.cc/learn/built-in-libraries/software-serial/
https://www.youtube.com/watch?v=OLYLtiz-Tzs
https://chatgpt.com/share/677d50a3-dd84-800e-b55f-1a5f128d9b83


---- 
#include <SoftwareSerial.h>

// GPS modülünün bağlı olduğu pinler
SoftwareSerial mySerial(10, 11); // RX = 10, TX = 11

void setup() {
  Serial.begin(9600); // PC ile iletişim için
  mySerial.begin(9600); // GPS modülü ile iletişim için
  Serial.println("GPS Modülü Kontrol Ediliyor...");
}


https://github.com/user-attachments/assets/bc9c1cb9-89a3-43a0-aafd-c749b38cee69

![WhatsApp Image 2025-01-07 at 4 38 24 PM](https://github.com/user-attachments/assets/f60ed35e-ca76-4d4b-ab73-e2ab57ae44f1)
![WhatsApp Image 2025-01-07 at 4 38 25 PM](https://github.com/user-attachments/assets/506f0d6a-69e0-4e68-800b-54d046a375bd)
![WhatsApp Image 2025-01-07 at 6 11 35 PM](https://github.com/user-attachments/assets/73aa316d-b2d6-4d9c-ae90-4d63bec7b3ce)
![WhatsApp Image 2025-01-07 at 6 11 36 PM](https://github.com/user-attachments/assets/998ada98-0423-4008-b244-b44cb797ec9b)


https://github.com/user-attachments/assets/06861457-6694-4ae3-9692-5f781a174b63


void loop() {
  while (mySerial.available()) {
    char c = mySerial.read();
    Serial.write(c); // GPS modülünden gelen veriyi bilgisayara yazdır
  }
}

----
Sinyal kontolü için bunu denedim Rx tx değiştirip 10 11 yaptım. Arduino uno var elimizde

Yanıp sönmeye başladı ama hiç bir şey yazdırmıyo

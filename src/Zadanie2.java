import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Zadanie2 {

     public static void main(String[] args) {
          File file = new File("file.txt");
          System.out.println("Podaj napis:");
          Scanner scanner = new Scanner(System.in);
          String outputText = scanner.nextLine();
          try(FileOutputStream stream = new FileOutputStream(file)) {

               byte[] mybytes = outputText.getBytes(StandardCharsets.UTF_8);
               stream.write(mybytes);

          } catch (IOException e) {
               e.printStackTrace();
          }

     }
}



import java.io.*;
import java.nio.charset.StandardCharsets;

public class Zadanie1 {
    public static void main(String[] args){

        File file = new File("file.txt");
        try { //try-with-resources == using()
            FileInputStream stream = new FileInputStream(file);
            InputStreamReader reader = new InputStreamReader(stream, StandardCharsets.UTF_8);

            char[] buffer = new char [256];
            StringBuilder builder = new StringBuilder();
            while (true) {
                int readBytes = reader.read(buffer,0, buffer.length);
                if (readBytes == -1) {
                    break;
                }
                builder.append(buffer, 0, readBytes);
            }
            String text = builder.toString();
            System.out.println(text);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    };
}

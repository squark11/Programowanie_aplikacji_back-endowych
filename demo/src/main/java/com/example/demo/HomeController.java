package com.example.demo;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
public class HomeController {

    @RequestMapping("/templates")
    public String templates(){
        return "index";
    }
    @RequestMapping("/test2")
    @ResponseBody
    public String index2(){
        return "Test2: Hello world!";
    }
    //http://localhost:8080/test2/jan&age=20&test=true
    @RequestMapping("/test2/{nazwa}")
    @ResponseBody
    public String index2(
        @PathVariable String nazwa,
        @RequestParam Integer age,
        @RequestParam Boolean test
    )
    {
        return "Hi " + nazwa + "! age: " + age + " test: " + test;
    }
}

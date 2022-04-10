package com.example.demo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import javax.annotation.PostConstruct;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;


@Controller
public class UsersController {
    @Autowired
    private UsersService usersService;
    @RequestMapping("/api/user")
    @ResponseBody
    public String getApiUsers() {return this.usersService.getUsers();}



    private final Object locker = new Object();
    private final Map<Long, UserEntity> users = new LinkedHashMap<>();

    @PostConstruct
    private void onCreate() { // it is executed only once imidiately after UsersController is created
        users.put(1L, new UserEntity(1L, "John"));
        users.put(2L, new UserEntity(2L, "Matt"));
        users.put(3L, new UserEntity(3L, "Kate"));
    }

    @RequestMapping("/users")
    @ResponseBody
    public Object getUser() {
        synchronized (this.locker) {
            return this.users;
        }
    }

    @RequestMapping("/users/{id}/get")
    @ResponseBody
    public Object getUser(@PathVariable Long id) {
        synchronized (this.locker) {
            return this.users.get(id);
        }
    }
    @RequestMapping("/users/{id}/remove")
    @ResponseBody
    public Object removeUser(@PathVariable Long id) {
        synchronized (this.locker) {
            return this.users.remove(id);
        }
    }
    @RequestMapping(
            value="/users/add",
            method = RequestMethod.POST,
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public Object addUser(@RequestBody UserEntity data) {
        return data;
        }
    }






using System.Collections.Generic;
using Celestial_Mods_V3.models;

public interface IAuth
{
    // Core authentication methods
    void init();
    void register(string username, string pass, string key, string email = "");
    void login(string username, string pass);
    void web_login();
    void license(string key);
    void logout();
    
    // Session/status methods
    void check();
    void CheckInit();
    
    // Account management
    void forgot(string username, string email);
    void upgrade(string username, string key);
    void ban(string reason = null);
    void changeUsername(string username);
    
    // Variable management
    string getvar(string var);
    void setvar(string var, string data);
    string var(string varid);
    
    // User info methods
    string expirydaysleft(string Type, int subscription);
    List<UsersModel> fetchOnline();
    void fetchStats();
    
    // Chat functionality  
    List<MessagesModel> chatget(string channelname);
    bool chatsend(string msg, string channelname);
    
    // Security check
    bool checkblack();
}
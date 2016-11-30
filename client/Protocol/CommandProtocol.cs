public class CommandProtocol
{
    public const int Login_InvalidMessage = 1000;
    public const int Login_InvalidAccount = 1001;
    public const int Login_InvalidPassword = 1002;
    public const int Login_Failed = 1003;
    public const int Login_Succeed = 1004;

    public const int Register_InvalidMessage = 1010;
    public const int Register_InvalidAccount = 1011;
    public const int Register_InvalidPassword = 1012;
    public const int Register_Failed = 1013;
    public const int Register_Succeed = 1014;

    public const int Reset_InvalidMessage = 1020;
    public const int Reset_InvalidAccount = 1021;
    public const int Reset_InvalidPassword = 1022;
    public const int Reset_Failed = 1023;
    public const int Reset_Succeed = 1024;

    public const int CreateRole_InvalidMessage = 1030;
    public const int CreateRole_UsernameNonExist = 1031;
    public const int CreateRole_UsernameExist = 1032;
    public const int CreateRole_Failed = 1033;
    public const int CreateRole_Succeed = 1034;

    public const int GetRole_InvalidMessage = 1040;
    public const int GetRole_RoleNonExist = 1041;
    public const int GetRole_RoleExist = 1042;
    public const int GetRole_Failed = 1043;
    public const int GetRole_Succeed = 1044;

    public const int UpdateRole_InvalidMessage = 1050;
    public const int UpdateRole_Failed = 1051;
    public const int UpdateRole_Succeed = 1052;

    public const int GetRoleInfo_InvalidMessage = 1060;
    public const int GetRoleInfo_Failed = 1061;
    public const int GetRoleInfo_Succeed = 1062;
}

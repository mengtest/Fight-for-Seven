package com.FightforSeven.protocol;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月27日 下午7:30:18 
 * @version 1.0 
 *
 */
public class CommandProtocol {
	public static final int Login_InvalidMessage = 1000;
	public static final int Login_InvalidAccount = 1001;
	public static final int Login_InvalidPassword = 1002;
	public static final int Login_Failed = 1003;
	public static final int Login_Succeed = 1004;
	
	public static final int Register_InvalidMessage = 1010;
	public static final int Register_InvalidAccount = 1011;
	public static final int Register_InvalidPassword = 1012;
	public static final int Register_Failed = 1013;
	public static final int Register_Succeed = 1014;
	
	public static final int Reset_InvalidMessage = 1020;
	public static final int Reset_InvalidAccount = 1021;
	public static final int Reset_InvalidPassword = 1022;
	public static final int Reset_Failed = 1023;
	public static final int Reset_Succeed = 1024;
	
	public static final int CreateRole_InvalidMessage = 1030;
	public static final int CreateRole_UsernameNonExist = 1031;
	public static final int CreateRole_UsernameExist = 1032;
	public static final int CreateRole_Failed = 1033;
	public static final int CreateRole_Succeed = 1034;
	
	public static final int GetRole_InvalidMessage = 1040;
	public static final int GetRole_RoleNonExist = 1041;
	public static final int GetRole_RoleExist = 1042;
	public static final int GetRole_Failed = 1043;
	public static final int GetRole_Succeed = 1044;
	
	public static final int UpdateRole_InvalidMessage = 1050;
	public static final int UpdateRole_Failed = 1051;
	public static final int UpdateRole_Succeed = 1052;
	
	public static final int GetRoleInfo_InvalidMessage = 1060;
	public static final int GetRoleInfo_Failed = 1061;
	public static final int GetRoleInfo_Succeed = 1062;
}

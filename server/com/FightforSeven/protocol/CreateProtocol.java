package com.FightforSeven.protocol;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:02:12 
 * @version 1.0 
 *
 */
public class CreateProtocol {
	public static final int Area_CreateRequest = 0;
	public static final int Area_CreateResponse = 1;

	public static final int Create_InvalidMessage = 0;
	public static final int Create_UsernameDK = 1;
	public static final int Create_UsernameOK = 2;
	public static final int Create_RoleDK = 3;
	public static final int Create_RoleOK = 4;
	public static final int Create_Failed = 5;
	public static final int Create_Succeed = 6;
}

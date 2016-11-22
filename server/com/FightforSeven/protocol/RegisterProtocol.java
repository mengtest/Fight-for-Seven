package com.FightforSeven.protocol;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月21日 下午10:01:51 
 * @version 1.0 
 *
 */
public class RegisterProtocol {
	public static final int Area_RegisterRequest = 0;
	public static final int Area_RegisterResponse = 1;

	public static final int Register_InvalidMessage = 0;
	public static final int Register_InvalidAccount = 1;
	public static final int Register_Failed = 2;
	public static final int Register_Succeed = 3;
}

package com.FightforSeven.protocol;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��21�� ����10:01:51 
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

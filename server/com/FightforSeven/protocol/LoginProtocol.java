package com.FightforSeven.protocol;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��21�� ����12:19:01
 * @version 1.0
 *
 */
public class LoginProtocol {
	public static final int Area_LoginRequest = 0;
	public static final int Area_LoginResponse = 1;

	public static final int Login_InvalidMessage = 0;
	public static final int Login_InvalidAccount = 1;
	public static final int Login_InvalidPassword = 2;
	public static final int Login_Failed = 3;
	public static final int Login_Succeed = 4;
}

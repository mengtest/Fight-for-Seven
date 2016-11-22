package com.FightforSeven.protocol;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 下午11:14:03
 * @version 1.0
 *
 */
public class ResetProtocol {
	public static final int Area_ResetRequest = 0;
	public static final int Area_ResetResponse = 1;

	public static final int Reset_InvalidMessage = 0;
	public static final int Reset_InvalidAccount = 1;
	public static final int Reset_InvalidPassword = 2;
	public static final int Reset_Failed = 3;
	public static final int Reset_Succeed = 4;
}

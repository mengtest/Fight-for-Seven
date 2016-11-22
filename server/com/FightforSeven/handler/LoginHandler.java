package com.FightforSeven.handler;

import java.util.List;

import org.apache.ibatis.session.SqlSession;

import com.FightforSeven.manager.AccountManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.Protocol;
import com.FightforSeven.protocol.LoginProtocol;

import io.netty.channel.ChannelHandlerContext;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 上午12:20:43
 * @version 1.0
 *
 */
public class LoginHandler {
	private volatile int num = 0;
	private static LoginHandler instance = new LoginHandler();

	public static LoginHandler getInstance() {
		return instance;
	}
	
	SqlSession sqlSession = null;

	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch (message.getArea()) {
		case LoginProtocol.Area_LoginRequest:
			loginResponse(ctx, message);
			break;
		default:
			break;
		}
	}

	public int checkAccount(ChannelHandlerContext ctx, SocketModel request) {
		List<String> message = request.getMessage();
		String account = message.get(0);
		String password = message.get(1);
		System.out.println(++num + " from client");
		return AccountManager.getInstance().checkAccount(account, password);
	}

	public void loginResponse(ChannelHandlerContext ctx, SocketModel request) {
		SocketModel response = new SocketModel();
		int command = checkAccount(ctx, request);
		
		response.setType(Protocol.TYPE_LOGIN);
		response.setArea(LoginProtocol.Area_LoginResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == LoginProtocol.Login_Succeed) {
			// TODO
		}
	}
}

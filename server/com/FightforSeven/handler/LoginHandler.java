package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.AccountManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.Protocol;
import com.FightforSeven.server.MainServer;
import com.FightforSeven.protocol.LoginProtocol;

import io.netty.channel.ChannelHandlerContext;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��21�� ����12:20:43
 * @version 1.0
 *
 */
public class LoginHandler extends BaseHandler{
	private volatile int num = 0;
	
	@Override
	public int getType() {
		return Protocol.TYPE_LOGIN;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch (message.getArea()) {
		case LoginProtocol.Area_LoginRequest:
			loginResponse(ctx, message);
			break;
		default:
			break;
		}
	}

	public int checkAccount(SocketModel request) {
		List<String> message = request.getMessage();
		String account = message.get(0);
		String password = message.get(1);
		System.out.println(++num + " from client");
		return AccountManager.getInstance().checkAccount(account, password);
	}

	public void loginResponse(ChannelHandlerContext ctx, SocketModel request) {
		SocketModel response = new SocketModel();
		int command = checkAccount(request);
		
		response.setType(Protocol.TYPE_LOGIN);
		response.setArea(LoginProtocol.Area_LoginResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == LoginProtocol.Login_Succeed) {
			MainServer.getInstance().channel2user.put(ctx.channel(), request.getMessage().get(0));  //��¼��¼�ɹ������Ӷ�Ӧ���˺�
			MainServer.getInstance().user2channel.put(request.getMessage().get(0), ctx.channel());  //��¼��¼�ɹ����˺Ŷ�Ӧ������
		}
	}
	
}

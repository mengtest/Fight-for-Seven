package com.FightforSeven.server;

import java.util.HashMap;
import java.util.Map;

import com.FightforSeven.decoder.LengthDecoder;
import com.FightforSeven.decoder.MessageDecoder;
import com.FightforSeven.encoder.MessageEncoder;
import com.FightforSeven.handler.BaseHandler;
import com.FightforSeven.handler.LoginHandler;
import com.FightforSeven.handler.RegisterHandler;
import com.FightforSeven.handler.ResetHandler;
import com.FightforSeven.protocol.Protocol;

import io.netty.bootstrap.ServerBootstrap;
import io.netty.channel.Channel;
import io.netty.channel.ChannelFuture;
import io.netty.channel.ChannelInitializer;
import io.netty.channel.ChannelOption;
import io.netty.channel.EventLoopGroup;
import io.netty.channel.group.ChannelGroup;
import io.netty.channel.group.DefaultChannelGroup;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.socket.SocketChannel;
import io.netty.channel.socket.nio.NioServerSocketChannel;
import io.netty.util.concurrent.GlobalEventExecutor;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��20�� ����10:50:52
 * @version 1.0
 *
 */
public class MainServer {
	private static MainServer instance;
	public Map<Object, BaseHandler> handlers = new HashMap<Object, BaseHandler>();  //ע��handlers
	
	public ChannelGroup channels = new DefaultChannelGroup(GlobalEventExecutor.INSTANCE);  //��¼��������
	public Map<Channel, String> channel2user = new HashMap<Channel, String>();  //��¼��¼�ɹ������Ӷ�Ӧ���˺�
	public Map<String, Channel> user2channel = new HashMap<String, Channel>();  //��¼��¼�ɹ����˺Ŷ�Ӧ������
	
	public static MainServer getInstance() {
		if(instance == null){
			instance = new MainServer();
		}
		return instance;
	}
	
	public void bind(int port) throws Exception {
		EventLoopGroup bossGroup = new NioEventLoopGroup();
		EventLoopGroup workGroup = new NioEventLoopGroup();
		try {
			ServerBootstrap b = new ServerBootstrap();
			b.group(bossGroup, workGroup).channel(NioServerSocketChannel.class).option(ChannelOption.SO_BACKLOG, 1024)// ���ͻ���������Ϊ1024
					.childHandler(new ChannelInitializer<SocketChannel>() {
						@Override
						protected void initChannel(SocketChannel ch) throws Exception {
							ch.pipeline().addLast(new LengthDecoder(1024, 0, 4, 0, 4));
							ch.pipeline().addLast(new MessageDecoder());
							ch.pipeline().addLast(new MessageEncoder());
							ch.pipeline().addLast(new ServerHandler());
						}
					});
			ChannelFuture f = b.bind(port).sync();
			if (f.isSuccess()) {
				System.out.println("Server starts success at port:" + port);
			}
			f.channel().closeFuture().sync();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			bossGroup.shutdownGracefully();
			workGroup.shutdownGracefully();
		}
	}

	public static void main(String[] args) throws Exception {
		
		MainServer.getInstance().handlers.put(Protocol.TYPE_LOGIN, new LoginHandler());
		MainServer.getInstance().handlers.put(Protocol.TYPE_REGISTER, new RegisterHandler());
		MainServer.getInstance().handlers.put(Protocol.TYPE_RESET, new ResetHandler());
		
		int port = 9981;
		MainServer.getInstance().bind(port);
	}
}
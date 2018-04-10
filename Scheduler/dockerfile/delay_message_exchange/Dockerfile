FROM rabbitmq

COPY rabbitmq_delayed_message_exchange-20171201-3.7.x /plugins/

RUN rabbitmq-plugins enable --offline rabbitmq_management
RUN rabbitmq-plugins enable --offline rabbitmq_delayed_message_exchange

EXPOSE 15671 15672

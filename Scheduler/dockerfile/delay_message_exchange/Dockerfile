FROM rabbitmq

COPY rabbitmq_delayed_message_exchange-0.0.1.ez /plugins/

RUN rabbitmq-plugins enable --offline rabbitmq_management
RUN rabbitmq-plugins enable --offline rabbitmq_delayed_message_exchange

EXPOSE 15671 15672

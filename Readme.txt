This is a demo project for learing the implementation of RabbitMQ

RabitMQproductAPI is a WebAPI which has a model class of Product with its attributes. The demo includes the message passing of the data that is sent to the WebAPI via a POST http method and the RabitMQConsole application subscribes to this message and is visible to the same.

The WebAPI has been created keeping the separations of concerns in mind, with separate interfaces and class methods, maintaining a clean architecture and DependencyInjection followed for decoupling.

Domain - no dependencies
Application - only dependant on Domain
Infrastructure - dependant on Application
Presentation - dependant on Application
             - dependant on infrastructure (only for service registration)


Domain:
    - Models
Application
    - Events
Infrastructure
    - Implementation for repositories etc   
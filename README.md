# APR_Comparator

erDiagram
    %% Контекст BANKS
    BANK {
        Guid Id
        String Name
        String Bic
    }
    BANK_CATEGORY {
        Guid Id
        String Code
        String Name
    }

    %% Контекст CBR (Центральный Банк)
    CBR_CATEGORY {
        Guid Id
        String Code
        String Description
    }
    CBR_LIMIT {
        Guid Id
        Decimal Value
        String Currency
    }
    CBR_STRATA {
        Guid Id
        Int32 Number
        String Type
    }
    CBR_VALIDATION {
        Guid Id
        Boolean IsValid
    }
    
    %% Контекст OFFERS
    OFFER {
        Guid Id
        String Code
        Decimal Rate
    }
    OFFER_VALIDATION {
        Guid Id
        String ErrorMessage
    }
    SPREAD {
        Guid Id
        Decimal Value
    }
    SPREAD_VALIDATION {
        Guid Id
        String RuleName
    }
    
    %% СВЯЗИ И ОШИБКИ ПРОЕКТИРОВАНИЯ (Синергия ошибок)
    BANK ||--o{ BANK_CATEGORY : "has (Категорийный разрыв)"
    BANK_CATEGORY }o--o{ CBR_CATEGORY : "Asymmetrical_Mapping (Дублирование)"
    
    CBR_STRATA ||--|| CBR_LIMIT : "Cyclic_Dependency_Start"
    CBR_LIMIT ||--|| CBR_STRATA : "Cyclic_Dependency_End"
    
    CBR_VALIDATION ||--|{ CBR_LIMIT : "Isolated_Validation_Scope"
    
    OFFER ||--|| SPREAD : "Direct_Coupling"
    OFFER ||--|| OFFER_VALIDATION : "Anemic_Domain_Validation"
    SPREAD ||--|| SPREAD_VALIDATION : "Externalized_State"
    
    %% Межконтекстная циклическая петля
    OFFER }o--|| BANK : "Belongs_To"
    CBR_STRATA }o--o{ OFFER : "Global_Leakage"

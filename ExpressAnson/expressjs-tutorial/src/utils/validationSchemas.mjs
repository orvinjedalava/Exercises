export const createUserValidationSchema = {
    username: {
        isLength: {
            options: {
                min: 5,
                max: 32
            },
            errorMessage: 'Username must be 5 to 32 characters'
        },
        notEmpty: {
            errorMessage: 'Username cannot be empty'
        },
        isString: {
            errorMessage: 'Username must be a string!'
        },
    },
    displayName: {
        notEmpty: {
            errorMessage: 'DisplayName cannot be empty'
        }
    }
}

export const createQueryValidationSchema = {
    filter: {
        isString: {
            errorMessage: 'Filter must be a string!'
        },
        notEmpty: {
            errorMessage: 'Filter cannot be empty'
        },
        isLength: {
            options: {
                min: 3,
                max: 32
            },
            errorMessage: 'Filter must be 3 to 32 characters'
        }
    },
    value: {
        isString: {
            errorMessage: 'Value must be a string'
        },
        notEmpty: {
            errorMessage: 'Value cannot be empty'
        }
    }
}
import * as Yup from 'yup';

export function getValidationSchema() {
    return Yup.object().shape({
        firstName: Yup.string()
            .required('First name is required'),
        lastName: Yup.string()
            .required('Last name is required'),
        email: Yup.string().email('Invalid email').required('Email is required'),
    });
}
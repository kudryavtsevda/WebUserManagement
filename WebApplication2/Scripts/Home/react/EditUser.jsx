import { withRouter } from "react-router";
import React from 'react';
import ReactDOM from 'react-dom';
import { Formik, Field, Form, useFormik } from 'formik';
import * as Yup from 'yup';
import 'materialize-css';
import { TextInput, Button, Icon } from 'react-materialize';
import { useHistory } from "react-router-dom";
import DataService from './DataService';

class EditUserComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Id: props.match.params.id,
            user: {},
            errorServerMessage: ''
        };

        this.validation = Yup.object().shape({
            firstName: Yup.string()
                .required('First name is required'),
            lastName: Yup.string()
                .required('Last name is required'),
            email: Yup.string().email('Invalid email').required('Email is required'),
        });


    }

    componentDidMount() {
        DataService.get(this.state.Id).then((response) => {
            console.log(response.data);
            this.setState({ user: response.data });
        });
    }

    updateUser(values) {
        console.log(values);
        DataService.update(this.state.Id, values)
            .then(response => {
                if (response.status != 200) {
                    this.setState({ errorServerMessage: "SERVER ERROR" })
                } else {
                    this.props.history.push("/");
                }
            })
            
    }

    render() {
        const initialValues = {
            firstName: this.state.user.FirstName ?? '',
            lastName: this.state.user.LastName ?? '',
            email: this.state.user.Email ?? '',
        };
        const errorServerMessage = this.state.errorServerMessage ?? "";

        return (
            <div>
                {errorServerMessage && <div>{errorServerMessage}</div>}
                <Formik
                    initialValues={initialValues}
                    validationSchema={this.validation}
                    enableReinitialize
                    onSubmit={(values) => this.updateUser(values)}
                >
                    {({ values, handleChange, errors }) => (
                        <Form>
                            <TextInput
                                id="firstName"
                                label="First Name"
                                value={values.firstName}
                                onChange={handleChange('firstName')}
                                error={errors.firstName ?? ''}
                                validate={false}
                            />
                            <TextInput
                                id="lastName"
                                label="Last Name"
                                value={values.lastName}
                                onChange={handleChange('lastName')}
                                error={errors.lastName ?? ''}
                                validate={false}
                            />
                            <TextInput
                                id="email"
                                label="Email"
                                value={values.email}
                                onChange={handleChange('email')}
                                error={errors.email ?? ''}
                                validate={false}
                            />
                            <Button node="button" type="submit" waves="light" icon={<Icon right>send</Icon>} >
                                Submit
                            </Button>
                            <Button node="button" waves="light" icon={<Icon right>arrow_back</Icon>} className="buttonClass">
                                Cancel
                            </Button>
                        </Form>
                    )}
                </Formik>
            </div>
        );
    }
}

export const EditUser = withRouter(EditUserComponent)
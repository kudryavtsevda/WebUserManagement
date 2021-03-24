import { withRouter } from "react-router";
import React from 'react';
import { Formik, Form } from 'formik';
import 'materialize-css';
import { TextInput, Button, Icon } from 'react-materialize';
import { ServerErrorSummary } from './ServerErrorSummary.jsx';
import DataService from './DataService';
import { getValidationSchema } from "./utils.js";

class AddUserComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {},
            errorServerMessage: ''
        };

        this.validation = getValidationSchema();
    }

    createUser(values) {
        DataService.create(values)
            .then(response => {
                this.backToMainScreen();
            })
            .catch(error => {
                console.log(error);
                this.setState({ user: values, errorServerMessage: error.response.data?.Message });
            });
    }

    backToMainScreen = () => {
        this.props.history.push("/");
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
                <ServerErrorSummary message={errorServerMessage} />

                <Formik
                    initialValues={initialValues}
                    validationSchema={this.validation}
                    enableReinitialize
                    onSubmit={(values) => this.createUser(values)}
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
                            <Button node="button" waves="light" icon={<Icon right>arrow_back</Icon>} onClick={this.backToMainScreen}>
                                Cancel
                            </Button>
                        </Form>
                    )}
                </Formik>
            </div>
        );
    }
}

export const AddUser = withRouter(AddUserComponent)
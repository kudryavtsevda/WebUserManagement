import { withRouter } from "react-router";
import React from 'react';
import { Formik, Form } from 'formik';
import 'materialize-css';
import { TextInput, Button, Icon } from 'react-materialize';
import DataService from './DataService';
import { ServerErrorSummary } from './ServerErrorSummary.jsx';
import { getValidationSchema } from "./utils";

class EditUserComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Id: props.match.params.id,
            user: {},
            errorServerMessage: ''
        };

        this.validation = getValidationSchema();
    }

    componentDidMount() {
        DataService.get(this.state.Id).then((response) => {
            console.log(response.data);
            this.setState({ user: response.data });
        });
    }

    updateUser(values) {
        DataService.update(this.state.Id, values)
            .then(response => {
                this.backToMainScreen()
            })
            .catch(error => {
                console.log(error);
                this.setState({ errorServerMessage: error.response.data?.Message });
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

export const EditUser = withRouter(EditUserComponent)
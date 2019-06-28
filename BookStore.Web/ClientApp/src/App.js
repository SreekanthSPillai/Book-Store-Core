import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import ContactList from './components/ContactList';

export default () => (
  <Layout>
      <Route exact path='/' component={ContactList} />
  </Layout>
);
